import { faEnvelope } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";

const ContactForm: React.FC = () => {
    const subjectType = [
        { label: 'Góp Ý', value: 1},
        { label: 'Báo Lỗi', value: 2},
        { label: 'Quảng Cáo', value: 3},
        { label: 'Quên Mật Khẩu', value: 4},
        { label: 'Khác', value: 3},
    ];
  
    return (
      <div className="contact-content p-2">
        <div className="w-full p-2 mb-2 rounded overflow-hidden border border-solid border-gray-300 dark:border-gray-300">
          <form>
            <h2 className="flex inline-block border-b-2 border-black mb-2 font-bold items-center text-xl	">
                <FontAwesomeIcon icon={faEnvelope} className="px-2"/>
                Liên Hệ
            </h2>
            <div className="form-group mb-2">
                <label
                    htmlFor="novel-name" 
                    className="col-sm-2 px-2">
                    Họ và tên
                </label>
                <input
                    placeholder="Nhập họ và tên"
                    type="text"
                    name="name"
                    className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                />
            </div>
            <div className="form-group mb-2">
                <label
                    htmlFor="novel-name" 
                    className="col-sm-2 px-2">
                    Email sử dụng
                </label>
                <input
                    placeholder="Nhập email"
                    type="text"
                    name="name"
                    className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                />
            </div>
            <div className="form-group mb-2">
                <label
                    htmlFor="novel-type" 
                    className="col-sm-2 px-2">
                    Loại truyện
                </label>
                <select
                    name="novelType"
                    className="px-1 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                >
                    <option value="" aria-disabled hidden>
                        Chọn loại truyện
                    </option>
                    {subjectType.map((subjectType, index) => (
                        <option key={index} value={subjectType.value}>
                            {subjectType.label}
                        </option>
                    ))}
                </select> 
            </div>
            <div className="form-group mb-2">
                <label
                    htmlFor="novel-name" 
                    className="col-sm-2 px-2">
                    Nội dung
                </label>
                <textarea
                    placeholder="Nhập nội dung cần hỗ trợ"
                    name="novel-description"
                    className="px-2 p-2 block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                />
            </div>    
            <div className="form-group mb-2 text-center">
                <button   
                    className="mx-auto px-4 p-2 mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                >Gửi</button>
            </div>
          </form>
        </div>
      </div>
    );
  };
  
  export default ContactForm;