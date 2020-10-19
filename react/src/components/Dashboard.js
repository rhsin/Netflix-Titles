import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Dashboard.scss';
import Titles from './Titles';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllTitles, getUser, showMessage, showError, resetError } from '../redux/actions';

function Dashboard() {
    const [refresh, setRefresh] = useState(false);
    const [details, setDetails] = useState(null);

    const dispatch = useDispatch();

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
    };

    const removeTitle = (id) => {
        axios.post(`${url}/Users/RemoveTitle/${id}/1`)
        .then(res => dispatch(showMessage(res.data)))
        .catch(err => dispatch(showError(err)));
        setRefresh(!refresh);
    };

    const getDetails = (title, type) => {
        if (type == 'TV Show') {
            type = 'series'
        };
        axios.get(`${url}/Titles/Details?title=${title}&type=${type}`)
        .then(res => setDetails(res.data))
        .catch(err => dispatch(showError(err)));
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
                    {error}
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
                    setDetails={() => setDetails(null)}
                />
            </div>
        </div>
    );
}

export default Dashboard;


    