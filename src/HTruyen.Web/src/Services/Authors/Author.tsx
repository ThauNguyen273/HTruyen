import axios from 'axios';

//const apiURL = 'https://59f8-1-53-8-6.ngrok-free.app/api';
const apiURL = 'http://localhost:7898/api'

export async function getAuthors() {
  const url = `${apiURL}/authors`; 
  return axios.get(url); 
}

export async function getAuthorById(id:any) {
  const url = `${apiURL}/author/${id}`;
  return axios.get(url);  
} 