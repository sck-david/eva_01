import React from 'react';
import './Home.css';
import Leaderboard from './Leaderboard';
import Profile from './Profile';
import Workouts from './Workouts';

const Home = () => {

    return (

        <div className="home-container">
            <h1>Willkommen bei EVA</h1>
            <h2>What to do?</h2>
            <div className="">
                <h3>Leaderboard</h3>
                <p>Vergleiche deinen Progress mit deinen Freunden und/oder Familie</p>
                <h3>Goals</h3>
                <p>Manage was und in welcher Zeitspanne du erreichen willst</p>
                <h3>Workouts</h3>
                <p>Erstelle Workouts um deinen Progress zu tracken</p>
                <h3>Profile</h3>
                <p>Veraendere wie deine Freunde dein Profil sehen</p>
            </div>
        </div>
    );
};

export default Home;