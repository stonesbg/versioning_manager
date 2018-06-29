import axios from 'axios';

// Firefox to ignore same origin about:config -> security.fileuri.strict_origin_policy -> false

export default () => {
  return axios.create({
    baseURL: 'http://yourdomain.com:5000/api',
    withCredentials: false,
    headers: {
      // 'Access-Control-Allow-Methods': 'POST, GET, OPTIONS',
      // 'Access-Control-Max-Age': '1000',
      // 'Access-Control-Allow-Headers': 'Content-Type',
      'Access-Control-Allow-Origin': '*',
      'Accept': 'application/json',
      'Content-Type': 'application/json',
    },
  });
};
