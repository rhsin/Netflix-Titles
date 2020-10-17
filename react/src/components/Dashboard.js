import React, { useEffect } from 'react';
import './Dashboard.scss';
import Titles from './Titles';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllTitles, getUser } from '../redux/actions';

function Dashboard() {
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
    }, []);

    return (
        <div className='container-grid'>
            {loading && <div className='alert'>Loading...</div>}
            {error && <div className='alert'>Error: {error}</div>}
            <div className='row-flex'>
                {user && (
                    <div className='card'>
                        <div className='card-title'>{user.name}</div> 
                        <div className='card-text'>{user.email}</div>
                        <div className='card-title'>Titles:</div>
                        <div>
                            {userTitles && userTitles.map(item => (
                                <div key={item.id} className='card-text'>
                                    {item.name} ({item.releaseDate})
                                </div>
                            ))}
                        </div>
                    </div>  
                )}
            </div>
            <div className='row-flex'>
                <Titles />
            </div>
        </div>
    );
}

export default Dashboard;


    