package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;
import javax.crypto.Cipher;

public class Giaima {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			FileInputStream fis = new FileInputStream("c:\\kp.txt");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			X509EncodedKeySpec spec = new X509EncodedKeySpec(buff);
			KeyFactory keyfac = KeyFactory.getInstance("RSA");
			RSAPublicKey kp = (RSAPublicKey) keyfac.generatePublic(spec);

			fis = new FileInputStream("c:\\ck.txt");
			buff = new byte[fis.available()];
			int n = fis.read(buff);
			fis.close();

			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.DECRYPT_MODE, kp);
			byte[] kq = cp.doFinal(buff, 0, n);

			for (int i = 0; i < kq.length; i++)
				System.out.print((char) kq[i]);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}