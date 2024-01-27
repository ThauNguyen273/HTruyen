import Api from '../ApiUrl/Api'

export const login = async (params:{email: string, password: string}) => {
  try {
    const response = await Api.post('/auth/login', params);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const register = async (params: { name: string; email: string; password: string; dateCreated: string }) => {
  try {
    const response = await Api.post('/auth/register', params);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const LoginAdmin = async (params:{email: string, password: string}) => {
  try {
    const response = await Api.post('/admin/login', params);
    return response.data;
  } catch (error) {
    throw error;
  }
};