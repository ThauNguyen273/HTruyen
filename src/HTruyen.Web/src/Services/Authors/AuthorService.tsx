import Api from "../ApiUrl/Api"

export interface AuthorShort{
    authorId: string
    authorName: string
}

export interface Author{
    id: string
    email: string
    name: string
    description?: string
    rankId?: string
    dateCreated: Date
    dateUpdated: Date
}

export interface Rank {
    id: string
    name: string
    benefit: string
}

export const GetAuthor = async (authorId: string): Promise<Author> => {
    try {
        const response = await Api.get(`/author/${authorId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateAuthor = async (authorId: string, params: {
    email: string,
    name: string,
    description?: string,
    rankId?: string,
    dateCreated: Date
    dateUpdated: Date
}): Promise<Author> => {
    try {
        const response = await Api.put(`/edit-author/${authorId}`, params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const CreateRank = async (params: {nam: string, benefit: string}): Promise<Rank> => {
    try {
        const response = await Api.post('/create-rank', params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const UpdateRank = async (rankId: string, params: {nam: string, benefit: string}): Promise<Rank> => {
    try {
        const response = await Api.post(`/edit-rank/${rankId}`, params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const DeleteRank = async (rankId: string): Promise<void> => {
    try {
        const response =await Api.delete(`/delete-rank/${rankId}`)
        return response.data
    } catch (error) {
        throw error
    }
}