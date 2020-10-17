import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Dashboard.scss';
import Titles from './Titles';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllTitles, getUser, showError, resetError } from '../redux/actions';

function Dashboard() {
    const [refresh, setRefresh] = useState(false);

    const dispatch = useDispatch();

    const user = useSelector(state => state.user);
    const loading = useSelector(state => state.loading);
    const error = useSelector(state => state.error);

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
        axios.post(`https://localhost:44315/api/Users/RemoveTitle/${id}/1`)
        .then(res => console.log(res.data))
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
                    Error: {error}
                </div>
            )}
            <div className='row-flex'>
                {user && (
                    <div className='card'>
                        <div className='card-title'>{user.name}</div> 
                        <div className='card-text'>{user.email}</div>
                        <div className='card-title'>Titles:</div>
                        <div>
                            {userTitles && userTitles.map(item => (
                                <div key={item.id} className='card-item'>
                                    <button className='btn-remove' onClick={()=> removeTitle(item.id)}>
                                        -
                                    </button>
                                    {item.name} ({item.releaseDate})
                                </div>
                            ))}
                        </div>
                    </div>  
                )}
            </div>
            <div className='row-flex'>
                <Titles setRefresh={()=> setRefresh(!refresh)} />
            </div>
        </div>
    );
}

export default Dashboard;


    