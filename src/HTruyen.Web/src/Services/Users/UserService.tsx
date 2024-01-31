import Api from "../ApiUrl/Api"
import { ChapterShort } from "../Chapters/ChapterService"
import { NovelShort } from "../Novels/NovelService"

{/* User */}

export interface UserShort{
    userId: string
    userName: string
}

export interface SearchUser {
    search?: string | null
    pageNumber?: number
    pageSize?: number
    isDescending?: boolean
}

export interface User {
    id: string
    email: string
    name: string
    address: string
    description: string
    gender: number
    dateCreated: Date
    dateUpdated: Date
}

export const GetUsers = async (params: SearchUser = {}): Promise<UserShort> => {
    try { 
        const response = await Api.get('/users', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetUser = async (userId: string): Promise<User> => {
    try {
        const response = await Api.get(`/user/${userId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateUser = async (userId: string, params: {
    email: string
    name: string
    address: string
    description: string
    gender: string
}): Promise<User> => {
    try {
        const response = await Api.put(`/edit-user/${userId}`, params)
        return response.data
    } catch (error) {
        throw error
    }
}

{/* UserView */}

export interface UserViewShort {
    viewId: string
    user: UserShort
    novel: NovelShort
    chapter: ChapterShort
}

export interface UserView {
    id: string
    userId: string
    user: UserShort
    novelId: string
    novel: NovelShort
    chapterId: string
    chapter: ChapterShort
}

export interface SearchView {
    search?: string | null
    pageNumber?: number
    pageSize?: number
    isDescending?: boolean
}

export const GetViews = async (params: SearchView = {}): Promise<UserViewShort> => {
    try {
        const response = await Api.get('/views', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetView = async (viewId: string): Promise<UserView> => {
    try {
        const response = await Api.get(`/view/${viewId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const CreateView = async (
    params: {
        userId: string, 
        novelId: string, 
        chapterId: string}): Promise<UserView> => {
    try {
        const response = await Api.post('/create-view',params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateView = async (
    viewId: string, 
    params: {
        userId: string, 
        novelId: string, 
        chapterId: string}): Promise<UserView> => {
            try {
                const response = await Api.put(`/edit-view/${viewId}`, params)
                return response.data
            } catch (error) {
                throw error
            }
}

export const DeleteView = async (viewId: string): Promise<void> => {
    try {
        const response = await Api.delete(`/delete-view/${viewId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

{/* UserFollow */}

export interface UserFollow {
    id: string
    userId: string
    user: UserShort
    novelId: string
    novel: NovelShort
}

export interface UserFollowShort {
    followId: string
    userId: string
    user: UserShort
    novelId: string
    novel: NovelShort
}

export interface SearchFollow {
    search?: string | null
    pageNumber?: number
    pageSize?: number
    isDescending?: boolean
}

export const GetFollows = async (params: SearchFollow = {}): Promise<UserFollowShort> => {
    try {
        const response = await Api.get('/follows', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetFollow = async (followId: string): Promise<UserFollow> => {
    try {
        const response = await Api.get(`/follow/${followId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const CreateFollow = async (
    params: {
        userId: string, 
        novelId: string, 
        chapterId: string}): Promise<UserFollow> => {
    try {
        const response = await Api.post('/create-follow',params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateFollow = async (
    followId: string, 
    params: {
        userId: string, 
        novelId: string, 
        chapterId: string}): Promise<UserFollow> => {
            try {
                const response = await Api.put(`/edit-follow/${followId}`, params)
                return response.data
            } catch (error) {
                throw error
            }
}

export const DeleteFollow = async (followId: string): Promise<void> => {
    try {
        const response = await Api.delete(`/delete-follow/${followId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

{/* UserFavorite */}

export interface UserFavorite {
    id: string
    userId: string
    user: UserShort
    novelId: string
    novel: NovelShort
}

export interface UserFavoriteShort {
    likeId: string
    userId: string
    user: UserShort
    novelId: string
    novel: NovelShort
}

export interface SearchFavorite {
    search?: string | null
    pageNumber?: number
    pageSize?: number
    isDescending?: boolean
}

export const GetLikes = async (params: SearchFavorite = {}): Promise<UserFavoriteShort> => {
    try {
        const response = await Api.get('/favorites', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetLike = async (likeId: string): Promise<UserFavorite> => {
    try {
        const response = await Api.get(`/favorite/${likeId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const CreateLike = async (
    params: {
        userId: string, 
        novelId: string, 
        chapterId: string}): Promise<UserFavorite> => {
    try {
        const response = await Api.post('/create-favorite',params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateLike = async (
    likeId: string, 
    params: {
        userId: string, 
        novelId: string, 
        chapterId: string}): Promise<UserFavorite> => {
            try {
                const response = await Api.put(`/edit-favorite/${likeId}`, params)
                return response.data
            } catch (error) {
                throw error
            }
}

export const DeleteLike = async (likeId: string): Promise<void> => {
    try {
        const response = await Api.delete(`/delete-favorite/${likeId}`)
        return response.data
    } catch (error) {
        throw error
    }
}