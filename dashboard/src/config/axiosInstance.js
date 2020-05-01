import axios from 'axios';
import {toast} from 'react-toastify';
toast.configure({
  autoClose: 8000,
  draggable: false
});
let axiosInstance = axios.create({
    // baseURL: 'http://localhost:5000',
    timeout: 10000,
    headers: { "Access-Control-Allow-Origin": "*"},
  });
  axiosInstance.interceptors.response.use(function (response) {
    return response;
  }, function (error) {
    if (error.response.status===500) {
      toast.error(error.response.data.Message);

    }
    if (error.response.status === 400) {
      toast.error(error.response.data.Message);
    }
    if (error.response.status === 401) {
      window.location.href = "/";
    }
    if (error.response.status === 404) {
        toast.error(error.response.data.Message);
    }
    
    return Promise.reject(error);
  });
  axiosInstance.interceptors.request.use(
    reqConfig => {
      if (!reqConfig.url.includes('/public'))
      {
        reqConfig.headers['Authorization'] = `Bearer ${localStorage.getItem('userToken')}`;
        return reqConfig;
      }
    },
    err => Promise.reject(err),
  );
export default axiosInstance;