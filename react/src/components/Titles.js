import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';

function Titles({ setRefresh }) {
    const [search, setSearch] = useState('');

    const dispatch = useDispatch();

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
                        <div className='card-title'>
                            {item.name}
                        </div>
                    </div>    
                ))}
            </div>
        </div>
    );
}

export default Titles;


    