import React, { Component, useEffect } from 'react';
import Routes from '../src/components/Routes';
import TopNavigation from './components/topNavigation';
import SideNavigation from './components/sideNavigation';
import Footer from './components/Footer';
import './index.css';
import 'react-toastify/dist/ReactToastify.min.css';
import Loader from 'react-loader-spinner';
import { useDispatch, useSelector } from 'react-redux';
import axiosInstance from './config/axiosInstance';
import './App.css';
import { useHistory } from 'react-router-dom';

const App = () => {
  const history = useHistory();
  const token = useSelector(state => state.token);
  const dispatch = useDispatch();
  const loading = useSelector(state => state.loading);
  const getAdminTypes = async () => {

    try {
     handleLoading(true)

      const response = await axiosInstance.get('/Public/v1/Application/UserTypes');
      dispatch({adminTypes: response.data.data, type: 'SET_ADMINTYPES'});
      handleLoading(false)
      
    } catch (error) {
      handleLoading(false)
    }
  }
  const getOrganizations = async () => {
    try {
      handleLoading(true)
      const response = await axiosInstance.get('/Public/v1/Organization/Organizations');
      dispatch({organizations: response.data.data, type: 'SET_ORGANIZATIONS'});
    handleLoading(false)

    } catch (error) {
    handleLoading(false)

      console.log(error)
    }

  }
  const getUserData = async () => {
    try {
    handleLoading(true)

      const response = await axiosInstance.get('/Public/v1/Auth/Admin');
      dispatch({user: response.data.data, type:'SET_USER_PERMISSIONS'});
    handleLoading(false)

    } catch (error) {
    handleLoading(false)
      
    }        
  }
  const handleLoading = (loadingStatus) => {
    dispatch({loading: loadingStatus, type: 'SHOW_LOADING'});
  }
  useEffect(() => {
    getAdminTypes();
    getOrganizations();
    if(token) 
    getUserData();
    else history.push('/');
  },[]);


    return (
        <React.Fragment>
          <div className={`flexible-content rtl ${loading ? 'app-loading' : ''}`}>
         
         {
           token ? 
           <React.Fragment>
             <TopNavigation />
              <SideNavigation />
           </React.Fragment>
         : null
         }
         <main className={token ? 'p-5 content' : 'content-auth'}>
           <Routes />
           
         </main>
       </div>
       <Loader
       className="loading"
       type="Circles"
       color="#6b3586 "
       height={100}
       width={100}
       timeout={20000000}
       visible={loading}
     /> 
        </React.Fragment>
    );
}

export default App;
