import axios from 'axios';

const Api = axios.create({
  baseURL: process.env.REACT_APP_ENP,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default Api;