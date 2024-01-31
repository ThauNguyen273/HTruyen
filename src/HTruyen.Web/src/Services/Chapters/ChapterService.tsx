import Api from '../ApiUrl/Api'

export interface Chapter {
    id: string
    novelId: string
    chapterNumber: string
    name: string
    metalTitle: string
    content: string
    isVip?: boolean
    chapterPrice?: number
    chapterStatus: number
    dateCreated: string
    dateUpdated: string
}

export interface ChapterShort {
    chapterId: string
    chapterName: string
}

export interface SearchStatus {
    novelId?: string
    status?: number
    pageNumber?: number
    pageSize?: number
}

export interface SearchByNovelId {
    novelId?: string
    pageNumber?: number
    pageSize?: number
}

export interface SearchCountByNovel {
    novelId?: string
    status?: number
}

export interface SearchChapterParams {
    search?: string | null
    pageNumber?: number
    pageSize?: number
    isDescending?: boolean
}

export interface ReadChapter {
    chapterId: string
    status: number
}

export const CreateChapter = async (params: {
    novelId?: string
    chapterNumber: string
    name: string
    content: string
    dateCreated: string
}): Promise<Chapter> => {
    try {
        const response = await Api.post('/create-chapter',params)
        return response.data
    } catch (error) {
        throw error
    }
} 

export const UpdateChapter = async (chapterId: string,params: {
    chapterNumber: string
    name: string
    content: string
    dateUpdated: string
}):Promise<Chapter> => {
    try {
        const response = await Api.put(`edit-chapter/${chapterId}`, params)
        return response.data
    } catch (error) {
        throw error
    }

}

export const GetListShort = async (params: SearchChapterParams = {}): Promise<ChapterShort[]> => {
    try {
        const response = await Api.get('/chapters', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetListByStatus = async (params: {
    novelId?: string,
    status: number
    pageNumber: 1
    pageSize: 20
}): Promise<Chapter[]> => {
    try {
        const response = await Api.get('chapter/search-status', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetByStatus = async (params: {chapterId?: string, status: number}): Promise<Chapter> => {
    try {
        const response = await Api.get('chapter/status', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetCountByNovel = async (params: {novelId?:string, chapterStatus: number}): Promise<number> => {
    try {
        const response =await Api.get(`/chapter/count-novel`,{params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetChapter = async (chapterId: string): Promise<Chapter> => {
    try {
        const response = await Api.get(`/chapter/${chapterId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetByNovelId = async (novelId: string): Promise<Chapter[]> => {
    try {
        const response = await Api.get(`/novel/chapters/${novelId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const PostChapter = async (chapterId: string, params: {chapterStatus: number}): Promise<Chapter> => {
    try {
        const response = await Api.put(`/post-chapter/${chapterId}`, params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateVip = async (chapterId: string, params: {isVip: boolean, chapterPrice: number}): Promise<Chapter> => {
    try {
        const response = await Api.put(`/edit-vip/${chapterId}`, params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const DeleteChapter = async (chapterId: string): Promise<void> => {
    try {
        const response = await Api.delete(`/delete-chapter/${chapterId}`)
        return response.data
    } catch (error) {
        throw error
    }
}
