import Api from '../ApiUrl/Api'
import { AuthorShort } from '../Authors/AuthorService'
import { CategoryShort } from '../Categories/CategoryService'

export interface NovelShort{
  novelId?: string
  novelName: string
  author: AuthorShort
}

export interface Novel{
  id?: string
  authorId?: string
  author: AuthorShort
  categoryId?: string
  category: CategoryShort
  name: string
  metalTitle: string
  tqName?: string
  tqUrl?: string
  description?: Novel
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
  status?: number | null
  pageNumber?: 1
  pageSize?: 15
}

export interface NovelSearchStatus{
  status?: number
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
  categoryId?: string
  status: number 
  pageNumber?: number
  pageSize?: number
}

export interface NovelSearchAuthor{
  authorId?: string
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
  pageNumber?: number
  pageSize?: 20
  isDescending?: boolean
}

export interface NovelCreateParams {
  authorId?: string
  categoryId: string
  name: string 
  tqName?: string | null
  tqUrl?: string | null
  description: string
  categoryOT: number
  novelST: number
  status: number
  dateCreated: string
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

export const GetNovelByAuthor = async (params: NovelSearchAuthor): Promise<Novel[]> => {
  try {
    const response = await Api.get('/novel/search-author', {params})
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

export const GetNovel = async (novelId?: string): Promise<Novel> => {
  try {
    const response = await Api.get(`/novel/${novelId}`)
    return response.data
  } catch (error) {
    throw error
  }
}

export const GetNovelByAuthorId = async (authorId?: string): Promise<Novel[]> =>{
  try {
    const response = await Api.get(`/novel/author/${authorId}`)
    return response.data
  } catch (error) {
    throw error
  }
}

export const CreateNovel = async (params: {
  authorId?: string,
  categoryId: string,
  name: string,
  tqName?: string,
  tqUrl?: string,
  description: string,
  categoryOT: number,
  novelST: number,
  status: number,
  dateCreated: string
}): Promise<string> => {
  try {
    const response = await Api.post('/create-novel', params)
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