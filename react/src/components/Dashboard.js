import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Dashboard.scss';
import Titles from './Titles';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllTitles, fetchDetails, getUser, showMessage, showError, resetError } from '../redux/actions';

function Dashboard() {
    const [refresh, setRefresh] = useState(false);

    const dispatch = useDispatch();

    const details = useSelector(state => state.details);
    const user = useSelector(state => state.user);
    const loading = useSelector(state => state.loading);
    const error = useSelector(state => state.error);
    const url = useSelector(state => state.url);

    const userTitles = user.titleUsers && user.titleUsers.map(item => item.title);

    useEffect(()=> {
        dispatch(fetchAllTitles());
    }, []);

    useEffect(()=> {
        dispatch(getUser());
    }, [refresh]);

    const clearError = () => {
        dispatch(resetError());
        setRefresh(!refresh);
    };

    const removeTitle = (id) => {
        axios.post(`${url}/Users/RemoveTitle/${id}/${user.id}`)
        .then(res => dispatch(showMessage(res.data)))
        .catch(err => dispatch(showError(err)));
        setRefresh(!refresh);
    };

    const getDetails = (title, type) => {
        dispatch(fetchDetails(title, type));
        setRefresh(!refresh);
    };

    return (
        <div className='container-grid'>
            {loading && (<div className='alert'>Loading...</div>)}
            {error && (
                <div className='alert'>
                    <button className='btn-remove' onClick={()=> clearError()}>
                        Clear
                    </button>
                    <span className='alert-text'>
                        {error}
                    </span>
                </div>
            )}
            <div className='row-flex'>
                {user && (
                    <div className='card'>
                        <div className='card-title header'>{user.name}</div> 
                        <div className='card-text'>{user.email}</div>
                        <div className='card-title'>Titles:</div>
                        <div>
                            {userTitles && userTitles.map(item => (
                                <div key={item.id} className='card-item'>
                                    <button
                                        className='btn-remove'
                                        onClick={()=> removeTitle(item.id)}
                                    >
                                        -
                                    </button>
                                    <button
                                        className='btn-details'
                                        onClick={()=> getDetails(item.name, item.type)}
                                    >
                                        {item.name} ({item.releaseDate})
                                    </button>
                                </div>
                            ))}
                        </div>
                    </div>  
                )}
            </div>
            <div className='row-flex'>
                <Titles
                    details={details}
                    setRefresh={()=> setRefresh(!refresh)} 
                    getDetails={(title, type) => getDetails(title, type)}
                    clearDetails={() => clearError()}
                />
            </div>
        </div>
    );
}

export default Dashboard;


    