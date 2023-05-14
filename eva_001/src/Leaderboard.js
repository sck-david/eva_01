import React, { useState } from 'react';
import './Leaderboard.css';

const Leaderboard = () => {
    const [selectedMuscle, setSelectedMuscle] = useState(null);
    const [selectedExercise, setSelectedExercise] = useState(null);

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
                        <li className="leaderboard-item">
                            <span className="leaderboard-name">User 1</span>
                            <span className="leaderboard-score">100</span>
                        </li>
                        <li className="leaderboard-item">
                            <span className="leaderboard-name">User 2</span>
                            <span className="leaderboard-score">90</span>
                        </li>
                        <li className="leaderboard-item">
                            <span className="leaderboard-name">User 3</span>
                            <span className="leaderboard-score">80</span>
                        </li>

                        {/* Add more leaderboard items here */}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default Leaderboard;