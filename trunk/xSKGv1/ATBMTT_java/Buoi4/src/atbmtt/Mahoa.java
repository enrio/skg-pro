package atbmtt;

import java.io.*;
import java.security.*;
import java.security.interfaces.*;
import java.security.spec.*;

import javax.crypto.Cipher;

public class Mahoa {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {
			FileInputStream fis = new FileInputStream("c:\\ks.txt");
			byte[] buff = new byte[fis.available()];
			fis.read(buff);
			fis.close();

			PKCS8EncodedKeySpec spec = new PKCS8EncodedKeySpec(buff);
			KeyFactory keyfac = KeyFactory.getInstance("RSA");
			RSAPrivateKey ks = (RSAPrivateKey) keyfac.generatePrivate(spec);

			FileReader rd = new FileReader("c:\\tb.txt");
			BufferedReader brd = new BufferedReader(rd);
			String msg = brd.readLine();

			Cipher cp = Cipher.getInstance("RSA");
			cp.init(Cipher.ENCRYPT_MODE, ks);
			byte[] kq = cp.doFinal(msg.getBytes());

			FileOutputStream fos = new FileOutputStream("c:\\ck.txt");
			fos.write(kq);
			fos.close();

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
