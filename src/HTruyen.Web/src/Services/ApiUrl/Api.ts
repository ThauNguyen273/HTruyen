import axios from 'axios';

const API_BASE_URL = 'https://ht-api.corn207.top//api';

const Api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default Api;