const initialState = {
    loading: false,
    token: localStorage.getItem('userToken') || null,
    user: localStorage.getItem('user') ? localStorage.getItem('user') : 'user',
    admins: [],
    agents: [],
    depos: [],
    stations: [],
    adminTypes: [],
    organizations: []
  }
  const reducer = (state = initialState, action) => {
    switch (action.type) {
      case 'SHOW_LOADING': {
        return{
          ...state,
          loading: action.loading
        }
      }
      case 'SET_USER': {
        return {
          ...state,
          user: action.user
        }
      }
      case 'SET_TOKEN': {
        return {
          ...state,
          token: action.token
        }
      }
      case 'SET_ADMINS': {
        return {
          ...state,
          admins: action.admins
        }
      }
      case 'SET_AGENTS': {
        return {
          ...state,
          agents: action.agents
        }
      }
      case 'SET_STATIONS': {
        return {
          ...state,
          stations: action.stations
        }
      }
      case 'SET_DEPOS': {
        return {
          ...state,
          depos: action.depos
        }
      }
      case 'SET_ADMINTYPES': {
        return {
          ...state,
          adminTypes: action.adminTypes
        }
      }
      case 'SET_ORGANIZATIONS': {
        return {
          ...state,
          organizations: action.organizations
        }
      }
      default:
        return state
    }
  }
  export default reducer;
  