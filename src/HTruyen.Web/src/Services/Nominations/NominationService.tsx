import Api from "../ApiUrl/Api"
import { NovelShort } from "../Novels/NovelService"
import { UserShort } from "../Users/UserService"

export interface Nominations {
    id: string
    Rating: number
    content: string
    userId: string
    user: UserShort
    novelId: string
    novel: NovelShort
}

export const AddNomination = async (params: {
    rating?: number
    content?: string
    userId?: string
    novelId?:string
}): Promise<Nominations> => {
    try {
        const res = await Api.post('/create-nomination', params)
        return res.data
    } catch (error) {
        throw error
    }
}

export const DeleteNomination = async (nomiId?: string): Promise<void> => {
    try {
        const res = await Api.delete(`/delete-nomination/${nomiId}`)
        return res.data
    } catch (error) {
        throw error
    }
}

export const GetCount = async (novelId?: string): Promise<Nominations> => {
    try {
        const res = await Api.get(`/nomination/count-novel/${novelId}`)
        return res.data
    } catch (error) {
        throw error
    }
}

export const GetNomiByNovel = async (novelId?: string): Promise<Nominations[]> => {
    try {
        const res = await Api.get(`/nomination/search-novel/${novelId}`)
        return res.data
    } catch (error) {
        throw error
    }
}