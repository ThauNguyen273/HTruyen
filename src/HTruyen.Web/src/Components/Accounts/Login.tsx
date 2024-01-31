import { useState } from "react";
import { getAccountId, getRole, login } from "../../Services/Authentications/AccountService";
import { useNavigate  } from "react-router-dom";

export default function LoginAccount() {
  const navigate  = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleLogin = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    try {
        const token = await login({ email, password });
        // Lưu token vào local storage
        localStorage.setItem('token', token);
      
        const role = await getRole(token);
        const accountId = await getAccountId(token)
        // Lưu role vào local storage
        localStorage.setItem('role', role);
        localStorage.setItem('accountId', accountId)
        
        //Chuyển hướng đến trang chính sau khi đăng nhập thành công
        navigate('/');
        window.location.reload();
    } catch (error) {
      setError('Invalid email or password'); 
    }
  };
    return (
        <div>
            <div className="flex flex-col items-center min-h-screen pt-6 sm:justify-center sm:pt-0 bg-gray-50">
                <div>
                    <a href="/">
                    <img
                        src="/HTruyện-logos.png" 
                        alt="Logo"
                        className="h-20 w-20"
                    />
                    </a>
                </div>
                <h1 className="text-2xl">Đăng Nhập</h1>
                {error && <p className="text-red-500">{error}</p>}
                <div className="w-full px-6 py-4 mt-6 border boder-gray-200 overflow-hidden bg-white shadow-md sm:max-w-md sm:rounded-lg">
                    <form onSubmit={handleLogin}>
                        <div className="mt-4">
                            <label
                                htmlFor="email"
                                className="block text-sm font-medium text-gray-700 undefined"
                            >
                                Email
                            </label>
                            <div className="flex flex-col items-start">
                                <input
                                    type="email"
                                    name="email"
                                    value={email}
                                    onChange={(e) => setEmail(e.target.value)}
                                    className="block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                                    required
                                />
                            </div>
                        </div>
                        <div className="mt-4">
                            <label
                                htmlFor="password"
                                className="block text-sm font-medium text-gray-700 undefined"
                            >
                                Password
                            </label>
                            <div className="flex flex-col items-start">
                                <input
                                    type="password"
                                    name="password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    className="block w-full mt-1 border border-gray-300 rounded-md shadow-sm focus:border-indigo-300 focus:ring focus:ring-indigo-200 focus:ring-opacity-50"
                                    required
                                />
                            </div>
                        </div>
                        <div className="flex items-center justify-end mt-4">
                            <a
                                className="text-sm text-gray-600 underline hover:text-gray-900"
                                href="/signup"
                            >
                                Unregistered?
                            </a>
                            <button
                                type="submit"
                                className="inline-flex items-center px-4 py-2 ml-4 text-xs font-semibold tracking-widest text-white uppercase transition duration-150 ease-in-out bg-gray-900 border border-transparent rounded-md active:bg-gray-900 false"
                            >
                                Login
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}