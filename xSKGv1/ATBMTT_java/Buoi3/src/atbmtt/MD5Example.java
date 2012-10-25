package atbmtt;

import java.security.MessageDigest;

public class MD5Example {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			/*MessageDigest md5 = MessageDigest.getInstance("SHA-1");
			String str = "Hello world!";
			byte[] h = md5.digest(str.getBytes());
			for (int i = 0; i < h.length; i++)
				System.out.print(String.format("%X", h[i]) + " ");*/
			
			FileHasher x = new FileHasher();
		byte[] t=	x.ReadFileMD5("c:\\a.txt");
		for (int i = 0; i < t.length; i++)
			System.out.print(String.format("%X", t[i]) + " ");
		
		x.CreateFileMD5("c:\\toan.txt", "123456");

		} catch (Exception e) {
			e.printStackTrace();
		}

	}

}
