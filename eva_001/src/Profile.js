import React, { useState, useEffect } from 'react';
import './Profile.css';

const Profile = () => {
    const [userData, setUserData] = useState({
        name: 'Benutzername',
        email: 'benutzer@email.com',
        age: 30,
        height: 170,
        weight: 70,
        profilePicture: 'https://via.placeholder.com/150',
    });

    const [bmi, setBmi] = useState(null);

    useEffect(() => {
        calculateBmi();
    }, [userData.height, userData.weight]);

    const handleChange = (event) => {
        const { name, value } = event.target;
        setUserData({ ...userData, [name]: value });
    };

    const handleProfilePictureChange = (event) => {
        const file = event.target.files[0];
        const reader = new FileReader();

        reader.onloadend = () => {
            setUserData({ ...userData, profilePicture: reader.result });
        };

        if (file) {
            reader.readAsDataURL(file);
        }
        event.target.value = '';
    };

    const calculateBmi = () => {
        const heightInMeters = userData.height / 100;
        const calculatedBmi = (userData.weight / (heightInMeters * heightInMeters)).toFixed(1);
        setBmi(calculatedBmi);
    };

    return (
        <div className="profile-container">
            <div className="avatar-container">
                <img className="avatar" src={userData.profilePicture} alt="Profilbild" />
                <label className="file-upload-label">
                    Profilbild ändern
                    <input type="file" onChange={handleProfilePictureChange} style={{ display: 'none' }} />
                </label>
                <div className="user-name">{userData.name}</div>
            </div>
            <div className="user-details">
                <p>E-Mail: {userData.email}</p>
                <p>
                    Alter: <input type="number" name="age" value={userData.age} onChange={handleChange} />
                </p>
                <p>
                    Groesse: <input type="number" name="height" value={userData.height} onChange={handleChange} /> cm
                </p>
                <p>
                    Gewicht: <input type="number" name="weight" value={userData.weight} onChange={handleChange} /> kg
                </p>
            </div>
            <p>BMI: {bmi}</p>
        </div>
    );
};

export default Profile;
