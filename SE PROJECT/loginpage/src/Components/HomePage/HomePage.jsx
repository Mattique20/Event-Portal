import React, { useState } from 'react';
import './HomePage.css';

const HomePage = () => {
    const [action, setAction] = useState('');

    return (
        <div className={`wrapper${action}`}>
            {/* Your content goes here */}
        </div>    
    );
}

export default HomePage;
