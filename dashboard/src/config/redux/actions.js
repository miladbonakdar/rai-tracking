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
export const setAdmins = admins => {
  return {
    type: SET_ADMINS,
    admins
  }
} 
export const setAgents = agents => {
  return {
    type: SET_AGENTS,
    agents
  }
}
export const setDepos = depos => {
  return {
    type: SET_DEPOS,
    depos
  }
} 
export const setStations = stations => {
  return {
    type: SET_STATIONS,
    stations
  }
} 
export const setAdminTypes = adminTypes => {
  return {
    type: SET_ADMINTYPES,
    adminTypes
  }
} 
export const setOrganization = organizations => {
  return {
    type: SET_ORGANIZATIONS,
    organizations
  }
} 