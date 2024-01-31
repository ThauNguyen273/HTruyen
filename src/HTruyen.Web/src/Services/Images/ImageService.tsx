import Api from "../ApiUrl/Api"

export interface Image {
    id: string
    mediaType: string
    data?: ArrayBuffer | null
    userId?: string
    authorId?: string
    novelId?: string
    chapterId?: string
    dateCreated: Date
    dateUpdated: Date
}

export const GetImage = async (imageId: string): Promise<Image> => {
    try {
        const response = await Api.get(`/image/${imageId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetByUser = async (userId: string): Promise<Image> => {
    try {
        const response = await Api.get(`/image/user/${userId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetByAuthor = async (authorId: string): Promise<Image> => {
    try {
        const response = await Api.get(`/image/user/${authorId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetByNovel = async (novelId: string): Promise<Image> => {
    try {
        const response = await Api.get(`/image/user/${novelId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const GetByChapter = async (chapterId: string): Promise<Image> => {
    try {
        const response = await Api.get(`/image/user/${chapterId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

