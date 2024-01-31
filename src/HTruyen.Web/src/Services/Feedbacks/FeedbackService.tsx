import Api from "../ApiUrl/Api"

export interface Feedback {
    id: string
    name: string
    email: string
    subject: string
    Content: string
    status: number
    dataCreated: Date
}

export interface FeedbackShort {
    feedbackId: string
    status: number
    dataCreated: Date
}

export interface SearchFeedback {
    search?: string | null
    pageNumber?: number
    pageSize?: number
    isDescending?: boolean
}

export interface SearchFBStatus {
    status: number
    pageNumber?: number
    pageSize?: number
}

export const GetFBs = async (params: SearchFeedback = {}): Promise<FeedbackShort> => {
    try {
        const response = await Api.get('/feedbacks', {params})
        return response.data
    } catch (error) {
        throw error
    }
} 

export const GetFB = async (feedbackId: string):  Promise<Feedback> => {
    try {
        const response = await Api.get(`/feedback/${feedbackId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

export const SearchStatus = async (params: SearchFBStatus): Promise<Feedback> => {
    try {
        const response = await Api.get('/search-status', {params})
        return response.data
    } catch (error) {
        throw error
    }
}

export const CreateFB = async (params: {
    name: string,
    email: string,
    subject: string,
    status: string,
    dateCreated: Date
}): Promise<Feedback> => {
    try {
        const response = await Api.post('/create-feedback', params)
        return response.data
    } catch (error) {
        throw error
    }
}

export const DeleteFB = async (feedId: string): Promise<void> => {
    try {
        const response = await Api.delete(`/delete-feedback/${feedId}`)
        return response.data
    } catch (error) {
        throw error
    }
}

