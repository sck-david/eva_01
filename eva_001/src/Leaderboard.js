import React from 'react';
import './Leaderboard.css';

const Leaderboard = () => {
    const data = [
        { id: 1, name: 'User 1', score: 100 },
        { id: 2, name: 'User 2', score: 90 },
        { id: 3, name: 'User 3', score: 80 },
    ];

    return (
        <div className="leaderboard-container">
            <h2>Leaderboard</h2>
            <ul className="leaderboard-list">
                {data.map((item) => (
                    <li key={item.id}>
                        {item.name} - {item.score}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Leaderboard;