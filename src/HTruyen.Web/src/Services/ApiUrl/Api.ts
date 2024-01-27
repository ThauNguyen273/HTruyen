import axios from 'axios';

//const API_BASE_URL = 'http://localhost:5000/api';
const API_BASE_URL = 'https://relevant-jennet-painfully.ngrok-free.app/api';

const Api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default Api;