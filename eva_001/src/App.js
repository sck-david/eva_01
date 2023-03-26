import React, { Component } from 'react';
import './App.css';
import Leaderboard from './Leaderboard';
import Profile from './Profile';

export default class App extends Component {
    state = {
        activePage: 'home',
    };

    setActivePage = (page) => {
        this.setState({ activePage: page });
    };

    render() {
        const { activePage } = this.state;

        return (
            <div className="container">
                <div className="header">EVA</div>
                <div className="content-container">
                    {activePage === 'home' && <div className="title">Willkommen</div>}
                    {activePage === 'leaderboard' && <Leaderboard />}
                    {activePage === 'profile' && <Profile />}
                </div>
                <div className="footer">
                    <div className="footer-text" onClick={() => this.setActivePage('home')}>
                        Home
                    </div>
                    <div className="footer-text" onClick={() => this.setActivePage('leaderboard')}>
                        Leaderboard
                    </div>
                    <div className="footer-text" onClick={() => this.setActivePage('profile')}>
                        Profile
                    </div>
                </div>
            </div>
        );
    }
}