import Api from '../ApiUrl/Api'

export interface CategoryShort {
    id: string
    name: string
}

export interface Category {
    id: string
    name: string
    metalTitle: string
    description: string
}

export interface CategorySearchParams {
    search?:string | null
    pageNumber?: 1
    pageSize?: 70
    isDescending?: boolean
}

export const GetListShort = async (params: CategorySearchParams = {}): Promise<CategoryShort[]> => {
    try {
        const response = await Api.get('/categories', {params});
        return response.data;
    } catch (error) {
        throw error;
    }
}

export const GetList = async (): Promise<Category[]> => {
    try {
        const response = await Api.get('/categories-all');
        return response.data;
    } catch (error) {
        throw error;
    }
}

export const GetCategory = async (categoryDetailId: string): Promise<Category> => {
    try {
        const response = await Api.get(`/category/${categoryDetailId}`);
        return response.data;
    } catch (error) {
        throw error;
    }
}

export const CreateCategory = async (params: {name: string, description: string}): Promise<Category> => {
    try {
        const response = await Api.post('/create-category', params);
        return response.data;
    } catch (error) {
        throw error;
    }
}

export const UpdateCategory = async (categoryDetailId: string,params: {name: string, description: string}): Promise<Category> => {
    try {
        const response = await Api.put(`/edit-category/${categoryDetailId}`, params);
        return response.data;
    } catch (error) {
        throw error;
    }
}

export const DeleteCategory = async (categoryDetailId: string): Promise<void> => {
    try {
        await Api.delete(`/delete-category/${categoryDetailId}`);
    } catch (error) {
        throw error;
    }
}