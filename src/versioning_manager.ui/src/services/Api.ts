import axios from 'axios';

export default () => {
  return axios.create({
    baseURL: 'http://localhost:5000/api',
    withCredentials: false,
    headers: {
      // 'Access-Control-Allow-Methods': 'POST, GET, OPTIONS',
      // 'Access-Control-Max-Age': '1000',
      // 'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept',
      'Accept': 'application/json',
      'Content-Type': 'application/json',
    },
  });
};
