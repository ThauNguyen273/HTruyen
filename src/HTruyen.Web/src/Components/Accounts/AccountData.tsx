import { useEffect, useState } from "react"
import { Account, getAccount } from "../../Services/Authentications/AccountService";

const AccountInfo = (initialAccountId: any) => {
    const [account, setAccount] = useState<Account>()
    const [accountId, setAccountId] = useState(initialAccountId)

    useEffect(() => {
        if (accountId) {
          fetchAccountInfo();
        }
      }, [accountId]);
    
      const fetchAccountInfo = async () => {
        try {
          const accountData = await getAccount(accountId);
          setAccount(accountData);
        } catch (error) {
          console.error('Error fetching account info:', error);
        }
      };
    
      return {
        account,
        accountId,
        setAccountId,
      };
};
    
export default AccountInfo