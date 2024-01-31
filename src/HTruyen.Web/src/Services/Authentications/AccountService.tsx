import Api from '../ApiUrl/Api'
import { AuthorShort } from '../Authors/AuthorService'
import { UserShort } from '../Users/UserService'
import { WalletShort } from '../Wallets/WalletService'

export interface AccountShort {
  accountId: string
  accountName: string
  accountEmail: string
}

export interface SearchAccount {
  search: string | null
  pageNumber: 1
  pageSize: 20
  isDescending: boolean
}

export interface Account {
  id: string
  name: string
  password: string
  email: string
  userId: string
  user: UserShort
  authorId: string
  author: AuthorShort
  walletId: string
  wallet: WalletShort
  dateCreated: Date
  dateUpdated: Date
}

interface LoginRespose {
  token: string
}

export const getAccounts = async (params: SearchAccount = {
  search: null,
  pageNumber: 1,
  pageSize: 20,
  isDescending: false
}): Promise<AccountShort[]> => {
  try {
    const response = await Api.get('/auth/accounts', {params});
    return response.data;
  } catch (error) {
    throw error
  }
}

export const getAccount = async (accountId: string): Promise<Account> => {
  try {
    const response = await Api.get(`/auth/account/${accountId}`)
    return response.data
  } catch (error) {
    throw error
  }
}

export const getRole = async (token: string): Promise<string> => {
  try {
    const response = await Api.get('auth/get-role', {
      params: { token },
    });
    const data = response.data as { role: string }; 
    return data.role;
  } catch (error) {
    throw error
  }
};

export const getAccountId = async (token: string): Promise<string> => {
  try {
    const response = await Api.get('auth/get-account-role', {
      params: { token },
    })
    const data = response.data as { accountId: string }
    return data.accountId
  } catch (error) {
    throw error
  }
}

export const login = async (credentials: { email: string; password: string }): Promise<string> => {
  try {
    const response = await Api.post('auth/login', credentials);
    const data = response.data as LoginRespose;
    return data.token;
  } catch (error) {
    throw error
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

export const changePassword = async (
  accountId: string, 
  params: {
    oldPassword: string, 
    newPassword: string, 
    confirmPassword: string }) => {
  try {
    const response = await Api.post(`/change-password/${accountId}`, params)
    return response.data
  } catch (error){
    throw error
  }
}

export const logout = async (token: string) => {
  try {
    const response = await Api.post('auth/logout', { params: {token}})
    return response.data
  } catch (error) {
    throw error
  }
}

export const deleteAccount = async (accountId: string): Promise<void> => {
  try {
    const response = await Api.delete(`/auth/delete-account/${accountId}`)
    return response.data
  } catch (error) {
    throw error
  }
}