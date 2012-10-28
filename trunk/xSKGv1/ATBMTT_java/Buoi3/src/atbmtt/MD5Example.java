package atbmtt;

import java.security.*;

public class MD5Example {
	public static void main(String[] args) {
		try {
			MessageDigest md5 = MessageDigest.getInstance("MD5");
			String str = "Hello world!";
			byte[] h = md5.digest(str.getBytes());
			for (int i = 0; i < h.length; i++)
				System.out.print(String.format("%X", h[i]) + " ");

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
