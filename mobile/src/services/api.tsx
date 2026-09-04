import axios from 'axios';

const api = axios.create({
  baseURL: 'https://starring-purse-blabber.ngrok-free.dev',
  timeout: 10000,
});

export default api;