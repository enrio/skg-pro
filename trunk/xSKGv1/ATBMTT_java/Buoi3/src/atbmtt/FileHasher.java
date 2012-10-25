package atbmtt;

import java.io.*;
import java.security.*;

public class FileHasher {
	public byte[] ReadFileMD5(String filename) throws Exception {
		InputStream fis = new FileInputStream(filename);

		byte[] buffer = new byte[1024];
		MessageDigest complete = MessageDigest.getInstance("MD5");
		int numRead;

		do {
			numRead = fis.read(buffer);
			if (numRead > 0) {
				complete.update(buffer, 0, numRead);
			}
		} while (numRead != -1);

		fis.close();
		return complete.digest();
	}

	public void CreateFileMD5(String filename, String data) throws Exception {

		FileWriter fstream = new FileWriter(filename);
		BufferedWriter out = new BufferedWriter(fstream);

		MessageDigest complete = MessageDigest.getInstance("MD5");
		byte[] h = complete.digest(data.getBytes());
		System.out.println();
		for (int i = 0; i < h.length; i++)
		{
			System.out.print(String.format("%X", h[i]) + " ");
			out.write(String.format("%X", h[i]) + " ");
		}
		out.close();
	}

	public static String getMD5Checksum(String filename) throws Exception {
		FileHasher x = new FileHasher();
		byte[] b = x.ReadFileMD5(filename);
		String result = "";

		for (int i = 0; i < b.length; i++) {
			result += Integer.toString((b[i] & 0xff) + 0x100, 16).substring(1);
		}
		return result;
	}
}
