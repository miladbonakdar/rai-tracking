export const SHOW_LOADING = 'SHOW_LOADING';
export const USER_AUTH = 'USER_AUTH';
export const showLoading = loading => {
  return {
    type: SHOW_LOADING,
    loading
  };
};
export const userAuth = user => {
  return {
    type: USER_AUTH,
    user
  }
}
