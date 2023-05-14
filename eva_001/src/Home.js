import React, { useState } from 'react';
import './Home.css';
import Leaderboard from './Leaderboard';
import Profile from './Profile';
import Workouts from './Workouts';

const Home = () => {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();

        console.log(`Username: ${username}, Email: ${email}, Password: ${password}`);
    };

    return (
        <div className="home-container">
            <h1>Welcome to EVA</h1>
            <div className="login-form">
                <h3>Login</h3>
                <form onSubmit={handleSubmit}>
                    <label>
                     Username:
                        <input type="text" value={username} onChange={e => setUsername(e.target.value)} />
                    </label>
                    <label>
                        Email:
                        <input type="email" value={email} onChange={e => setEmail(e.target.value)} />
                    </label>
                    <label>
                        Password:
                        <input type="password" value={password} onChange={e => setPassword(e.target.value)} />
                    </label>
                    <input type="submit" value="Log in" />
                </form>
            </div>
        </div>
    );
};

export default Home;
