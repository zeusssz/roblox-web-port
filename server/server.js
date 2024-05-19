const express = require('express');
const axios = require('axios');
const cors = require('cors');

const app = express();
const port = 3000;

// Use CORS to allow requests from your frontend
app.use(cors());

// Your Roblox API key
const ROBLOX_API_KEY = 'YOUR_ROBLOX_API_KEY';

// Example endpoint to get user information
app.get('/user/:username', async (req, res) => {
    const username = req.params.username;
    try {
        const response = await axios.get(`https://apis.roblox.com/users/v1/users?usernames=${username}`, {
            headers: {
                'x-api-key': ROBLOX_API_KEY
            }
        });
        res.json(response.data);
    } catch (error) {
        res.status(500).send('Error retrieving user data');
    }
});

app.listen(port, () => {
    console.log(`Server running at http://localhost:${port}`);
});
