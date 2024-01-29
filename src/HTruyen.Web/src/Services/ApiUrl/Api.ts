import axios from 'axios';

const Api = axios.create({
  baseURL: import.meta.env.VITE_APIURL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default Api;
