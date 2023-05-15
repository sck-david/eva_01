import React, { useState, useEffect, Component } from 'react';
import './Home.css';
import Leaderboard from './Leaderboard';
import Profile from './Profile';
import Workouts from './Workouts';


export default class Home extends Component {

    Home = () => {
        const [username, setUsername] = useState('');
        const [email, setEmail] = useState('');
        const [password, setPassword] = useState('');
        const [data, setData] = useState(null);


        const { activePage } = this.state;

        setActivePage = (page) => {
            this.setState({ activePage: page });
        };

        const handleSubmit = (event) => {
            event.preventDefault();
            console.log(`Username: ${username}, Email: ${email}, Password: ${password}`);

            data.map(item => {
                if (username == item.username && email == item.email && password == item.password) {
                    activePage === 'workout' && <Workouts />
                }
            })
        };

        useEffect(() => {
            fetchData();
        }, []);

        const fetchData = async () => {
            try {
                const response = await fetch('https://localhost:7086/api/Home/getAllUsers'); // Replace with your API endpoint
                const json = await response.json();
                setData(json);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
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
                <div>
                    <ul className="leaderboard-list">

                        {data &&
                            data.map(item => (
                                <li className="list-items">
                                    <span className="leaderboard-name">{item.username}</span>
                                    <span className="leaderboard-workout" >{item.email}</span>
                                    <span className="leaderboard-score">{item.password}</span>
                                </li>
                            ))}

                        {/* Add more leaderboard items here */}
                    </ul>
                </div>
            </div>



        );
    };

}


