export const SHOW_LOADING = 'SHOW_LOADING';
export const USER_AUTH = 'SET_USER';
export const SET_TOKEN = 'SET_TOKEN'
export const showLoading = loading => {
  return {
    type: SHOW_LOADING,
    loading
  };
};
export const userAuth = user => {
  return {
    type: SET_USER,
    user
  }
}
export const setToken = token => {
  return {
    type: SET_TOKEN,
    token
  }
} 
