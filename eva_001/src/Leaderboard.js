import React from 'react';
import './Leaderboard.css';

const Leaderboard = () => {
    const data = [
        { id: 1, name: 'User 1', score: 100 },
        { id: 2, name: 'User 2', score: 90 },
        { id: 3, name: 'User 3', score: 80 },
        { id: 4, name: 'User 4', score: 70 },
        { id: 5, name: 'User 5', score: 60 },
        { id: 6, name: 'User 6', score: 50 },
        { id: 7, name: 'User 7', score: 40 },
        { id: 8, name: 'User 8', score: 30 },
        { id: 9, name: 'User 9', score: 20 },
        { id: 10, name: 'User 10', score: 10 },
        { id: 11, name: 'User 11', score: 85 },
        { id: 12, name: 'User 12', score: 75 },
        { id: 13, name: 'User 13', score: 55 },
        { id: 14, name: 'User 14', score: 45 },
        { id: 15, name: 'User 15', score: 35 },
        { id: 16, name: 'User 16', score: 25 },
        { id: 17, name: 'User 17', score: 15 },
        { id: 18, name: 'User 18', score: 5 },
        { id: 19, name: 'User 19', score: 70 },
        { id: 20, name: 'User 20', score: 30 },
    ];

    return (
        <div className="leaderboard-container">
            <h2 className="leaderboard-heading">Leaderboard</h2>
            <div className="leaderboard-scroll">
                <ul className="leaderboard-list">
                    {data.map((item) => (
                        <li key={item.id} className="leaderboard-item">
                            <span className="leaderboard-name">{item.name}</span>
                            <span className="leaderboard-score">{item.score}</span>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default Leaderboard;
