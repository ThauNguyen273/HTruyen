import React, { useEffect } from "react";

interface NotificationSuccessProps {
  message: string;
  onClose: () => void;
}

const NotificationSuccess: React.FC<NotificationSuccessProps> = ({ message, onClose }) => {
  useEffect(() => {
    const timeout = setTimeout(() => {
      onClose();
    }, 3000); // Close the notification after 3 seconds

    return () => clearTimeout(timeout);
  }, [onClose]);

  return (
    <div className="fixed bottom-4 right-4 bg-green-500 text-white p-4 rounded-md flex justify-between items-center shadow-md">
      <p>{message}</p>
      <button className="text-white" onClick={onClose}>&times;</button>
    </div>
  );
};

export default NotificationSuccess;