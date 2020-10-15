import React, { useState } from 'react';
import { useSelector } from 'react-redux';

function Titles({ setRefresh }) {
    const [search, setSearch] = useState('');

    const titles = useSelector(state => state.titles);

    return (
        <div className='card'>
            <form>
                <label htmlFor='search'>Search Titles</label>
                <input type='text' id='search' onChange={e => setSearch(e.target.value)} />
            </form>
            <div className='card-title'>Results: {titles.length}</div>
            <div>
                {titles.map((item, index) => index < 50 && (
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


    