export const SHOW_LOADING = 'SHOW_LOADING';

export const showLoading = loading => {
  return {
    type: SHOW_LOADING,
    loading
  };
};
