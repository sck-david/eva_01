import React from 'react';
import './Profile.css';

const Profile = () => {
    const userData = {
        name: 'Benutzername',
        email: 'benutzer@email.com',
        age: 30,
        weight: 70,
    };

    return (
        <div className="profile-container">
            <div className="avatar-container">
                <img className="avatar" src="https://via.placeholder.com/150" alt="Profilbild" />
                <div className="user-name">{userData.name}</div>
            </div>
            <div className="user-details">
                <p>E-Mail: {userData.email}</p>
                <p>Alter: {userData.age}</p>
                <p>Gewicht: {userData.weight} kg</p>
            </div>
        </div>
    );
};

export default Profile;