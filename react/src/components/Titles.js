import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchSearchTitles } from '../redux/actions';

function Titles() {
    const [search, setSearch] = useState('');
    const [order, setOrder] = useState('');

    const dispatch = useDispatch();

    const titles = useSelector(state => state.titles);

    const sortOrder = (e, order) => {
        e.preventDefault();
        setOrder(order);
    };

    const searchTitles = (e) => {
        e.preventDefault();
        dispatch(fetchSearchTitles(search, order));
    };

    return (
        <div className='card'>
            <form>
                <label htmlFor='search'>Search Titles</label>
                <input type='text' id='search' onChange={e => setSearch(e.target.value)} />
                <button className='btn blue' onClick={e => sortOrder(e, 'date_desc')}>
                    Order Desc.
                </button>
                <button className='btn red' onClick={e => sortOrder(e, 'date_asc')}>
                    Order Asc.
                </button>
                <button className='btn green' onClick={e => searchTitles(e)}>
                    Filter
                </button>
            </form>
            <div className='card-title'>Results: {titles.length}</div>
            <div>
                {titles.map((item, index) => index < 100 && (
                    <div key={item.id} className='card-list'>
                        <div className='card-title'>{item.name}</div>
                        <div className='card-text'>{item.type}</div>
                        <div className='card-text'>{item.releaseDate}</div>
                        <div className='card-text'>{item.genre}</div>
                        <div className='card-text'>{item.cast}</div>
                        <div className='card-text'>{item.description}</div>
                    </div>    
                ))}
            </div>
        </div>
    );
}

export default Titles;


    