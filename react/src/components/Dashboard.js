import React, { useState, useEffect } from 'react';
import './Dashboard.scss';
import Titles from './Titles';
import { useDispatch, useSelector } from 'react-redux';
import { fetchAllTitles, getUser } from '../redux/actions';

function Dashboard() {
    const [refresh, setRefresh] = useState(false);

    const dispatch = useDispatch();

    const user = useSelector(state => state.user);
    const loading = useSelector(state => state.loading);
    const error = useSelector(state => state.error);

    // useEffect(()=> {
    //     dispatch(fetchAllTitles());
    // }, []);

    // useEffect(()=> {
    //     dispatch(getUser());
    // }, [refresh]);

    return (
        <div className='container-grid'>
            {loading && <div className='alert'>Loading...</div>}
            {error && <div className='alert'>Error: {error}</div>}
            <div className='row-flex'>
                {user && (
                    <div className='card'>
                        <div className='card-title'>{user.data.name}</div> 
                        <div className='card-text'>{user.data.email}</div>
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


    