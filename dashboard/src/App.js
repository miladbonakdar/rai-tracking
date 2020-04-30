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

const App = () => {

  const dispatch = useDispatch();
  const loading = useSelector(state => state.loading);
  const getAdminTypes = async () => {

    dispatch({loading: true, type: 'SHOW_LOADING'});
    try {
      const response = await axiosInstance.get('/Public/v1/Auth/AdminTypes');
      dispatch({adminTypes: response.data.data, type: 'SET_ADMINTYPES'});
    } catch (error) {
      
    }
    dispatch({loading: false, type: 'SHOW_LOADING'});
  }
  const getOrganizations = async () => {
    dispatch({loading: true, type: 'SHOW_LOADING'});
    try {
      const response = await axiosInstance.get('/Public/v1/Organization/Organizations');
      dispatch({organizations: response.data.data, type: 'SET_ORGANIZATIONS'});
    } catch (error) {
      console.log(error)
    }
    dispatch({loading: false, type: 'SHOW_LOADING'});

  }
  useEffect(() => {
    getAdminTypes();
    getOrganizations();
  },[]);


    return (
        <React.Fragment>
          <div className={`flexible-content rtl ${loading ? 'app-loading' : ''}`}>
         
         <TopNavigation />
         <SideNavigation />
         <main id="content" className="p-5">
           <Routes />
           
         </main>
         <Footer />
        
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
