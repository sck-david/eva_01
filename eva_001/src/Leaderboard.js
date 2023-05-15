import React, { useState, useEffect } from 'react';
import './Leaderboard.css';

const Leaderboard = () => {
    const [selectedMuscle, setSelectedMuscle] = useState(null);
    const [selectedExercise, setSelectedExercise] = useState(null);
    const [data, setData] = useState(null);

    useEffect(() => {
        fetchData();
    }, []);

    const exercises = [
        { id: 1, name: 'Bench Press', muscle: 'Chest' },
        { id: 2, name: 'Squat', muscle: 'Legs' },
        { id: 3, name: 'Pull-ups', muscle: 'Back' },
        { id: 4, name: 'Shoulder Press', muscle: 'Shoulders' },
        { id: 5, name: 'Bicep Curls', muscle: 'Arms' },
        { id: 6, name: 'Crunches', muscle: 'Abs' },
    ];

    const muscleGroups = ['Chest', 'Legs', 'Back', 'Shoulders', 'Arms', 'Abs'];

    const handleMuscleClick = (muscle) => {
        setSelectedMuscle(muscle);
        setSelectedExercise(null);
    };

    const handleExerciseClick = (exercise) => {
        setSelectedExercise(exercise);
    };

    const filteredExercises = exercises.filter(
        (exercise) => (!selectedMuscle || exercise.muscle === selectedMuscle)
    );

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7086/api/Home/getAllStats'); // Replace with your API endpoint
            const json = await response.json();
            setData(json);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    return (
        <div className="leaderboard-container">
            <h2 className="leaderboard-heading">Leaderboard</h2>
            <div className="button-container">
                <h3 className="header">Muscle Group:</h3>
                {muscleGroups.map((muscle) => (
                    <button
                        key={muscle}
                        className={`button ${selectedMuscle === muscle ? 'selected' : ''}`}
                        onClick={() => handleMuscleClick(muscle)}
                    >
                        {muscle}
                    </button>
                ))}
                {selectedMuscle && (
                    <div>
                        <h3 className="header">Exercises:</h3>
                        {filteredExercises.map((exercise) => (
                            <button
                                key={exercise.id}
                                className={`button ${selectedExercise === exercise ? 'selected' : ''}`}
                                onClick={() => handleExerciseClick(exercise)}
                            >
                                {exercise.name}
                            </button>
                        ))}
                    </div>
                )}
            </div>
            {selectedExercise && (
                <div className="leaderboard-scroll">
                    <ul className="leaderboard-list">
                        {/* Replace the dummy data with actual user scores */}
                        {/*<li className="leaderboard-item">*/}
                        {/*    <span className="leaderboard-name">User 1</span>*/}
                        {/*    <span className="leaderboard-score">100</span>*/}
                        {/*</li>*/}
                        
                        {data &&
                            data.map(item => (
                                <li className="list-items">
                                    <span className="leaderboard-name">{item.username}</span>
                                    <span className="leaderboard-workout" >{item.workoutname}</span>
                                    <span className="leaderboard-score">{item.score}</span>
                                </li>
                            ))}

                        {/* Add more leaderboard items here */}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default Leaderboard;