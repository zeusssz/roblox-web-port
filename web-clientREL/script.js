document.getElementById('inputForm').addEventListener('submit', async function (e) {
    e.preventDefault();
    
    const playerName = document.getElementById('playerName').value;
    const command = document.getElementById('command').value;

    const input = {
        playerName: playerName,
        command: command
    };

    try {
        const response = await fetch('https://localhost:5001/api/userinput', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(input)
        });
        const result = await response.text();
        document.getElementById('response').textContent = result;
    } catch (error) {
        console.error('Error sending input:', error);
    }
});
