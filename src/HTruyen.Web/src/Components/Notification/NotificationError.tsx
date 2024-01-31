import React, { useEffect } from "react";

interface NotificationErrorProps {
  message: string;
  onClose: () => void;
}

const NotificationError: React.FC<NotificationErrorProps> = ({ message, onClose }) => {
  useEffect(() => {
    const timeout = setTimeout(() => {
      onClose();
    }, 3000); // Close the error alert after 3 seconds

    return () => clearTimeout(timeout);
  }, [onClose]);

  return (
    <div className="bg-red-200 text-red-800 border border-red-400 rounded p-4 mb-2">
      <p>{message}</p>
      <button
        onClick={onClose}
        className="float-right text-sm text-red-600 focus:outline-none"
      >
        &#10005;
      </button>
    </div>
  );
};

export default NotificationError;