import Api from '../ApiUrl/Api'
import { AuthorShort } from '../Authors/AuthorService'
import { CategoryShort } from '../Categories/CategoryService'

export interface NovelShort{
  id: string
  name: string
  author: AuthorShort
}

export interface Novel{
  id: string
  authorId: string
  author: AuthorShort
  categoryId: string
  category: CategoryShort
  name: string
  metalTitle: string
  tqName?: string
  tqUrl?: string
  categoryOT: number
  novelST: number
  status: number
  dateCreated: Date
  dateUpdated: Date

}

export interface NovelSearchMany{
  name?: string | null
  categoryId?: string | null
  categoryOfType?: string | null
  novelStatusType?: string | null
  status?: string | null
  pageNumber?: 1
  pageSize?: 15
}

export interface NovelSearchStatus{
  status?: string
  pageNumber?: 1
  pageSize?: 15
}

export interface NovelSearchCategoryOT{
  categoryOfType: number 
  status: number 
  pageNumber?: number
  pageSize?: number
}

export interface NovelSearchCategory{
  categoryOfType: number
  categoryId: string
  status: number 
  pageNumber?: number
  pageSize?: number
}

export interface NovelSearchNewUpdate{
  status: number
  pageNumber?: number
  pageSize?: number
}

export interface NovelCountByCategory{
  categoryOfType: string
  categoryId: string
  status: string
}

export interface NovelSearchParams {
  search?:string | null
  pageNumber?: 1
  pageSize?: 70
  isDescending?: boolean
}

export const search = async (params: NovelSearchParams = {}): Promise<NovelShort[]> => {
  try {
    const response = await Api.get('/novels', {params});
    return response.data;
  } catch (error) {
    throw (error)
  }
}

export const SearchAdvanced = async (params: NovelSearchMany = {}): Promise<Novel[]> => {
  try {
    const response = await Api.get('/novel/search', {params})
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetNovelByStatus = async (params: NovelSearchStatus = {}): Promise<Novel[]> => {
  try {
    const response = await Api.get('/novel/search-status', {params})
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetNovelByCategoryOT = async (params: NovelSearchCategoryOT): Promise<Novel[]> => {
  try {
    const response = await Api.get('/novel/search-categoryOT', {params})
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetNovelByCategory = async (params: NovelSearchCategory): Promise<Novel[]> => {
  try {
    const response = await Api.get('/novel/search-category', {params})
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetNovelNewUpdate = async (params: NovelSearchNewUpdate): Promise<Novel[]> => {
  try {
    const response = await Api.get('/novel/search-new-update', {params})
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetCountByCategory = async (params: NovelCountByCategory): Promise<Novel> => {
  try {
    const response = await Api.get('/novel/count-category', {params})
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetAllCount = async (): Promise<Novel> => {
  try {
    const response = await Api.get('/novel/count-all')
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetNovel = async (novelId: string): Promise<Novel[]> => {
  try {
    const response = await Api.get(`/novel/${novelId}`)
    return response.data
  } catch (error) {
    throw error
  }
}

export const CreateNovel = async (params: {
  authorId: string
  categoryId: string
  name: string
  tqName?: string
  tqUrl?: string
  description: string
  categoryOT: number
  novelST: number
  status: 1
  dateCreated: string
}): Promise<Novel> => {
  try {
    const response = await Api.post('/create-nove', params)
    return response.data
  } catch (error) {
    throw error
  }
}

export const UpdateNovel = async (novelId: string,params: {
  categoryId: string
  name: string
  tqName?: string
  tqUrl?: string
  description: string
  categoryOT: number
  novelST: number
  dateUpdate: string
}): Promise<Novel> => {
  try {
    const response = await Api.put(`/edit-novel/${novelId}`, params)
    return response.data
  } catch (error) {
    throw error
  }
}

export const CensorNovel = async (novelId: string, params: {status: number}): Promise<Novel> => {
  try {
    const response = await Api.put(`/novel/censor-novel/${novelId}`, params)
    return response.data
  } catch (error) {
    throw error
  }
}

export const DeleteNovel = async (novelId: string): Promise<void> => {
  try {
    await Api.delete(`/delete-novel/${novelId}`)
  } catch (error) {
    throw error
  }
}